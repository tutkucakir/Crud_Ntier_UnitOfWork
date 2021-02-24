using BLL.UnitOfWorkPattern;
using MODEL.Entity;
using MODEL.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helpers;

namespace UI
{
    public partial class Form1 : Form
    {
        private readonly IUnitOfWork _unitOfWork;
        public Form1()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            GetAll();
            ButtonDefault();
        }

        private void GetAll()
        {
            listView1.Items.Clear();
            foreach (Student item in _unitOfWork.Students.SelectAll())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.FirstName;
                lvi.SubItems.Add(item.LastName);
                lvi.SubItems.Add(item.BirthDate.ToString());
                lvi.Tag = item;
                listView1.Items.Add(lvi);
            }
        }

        ToolHelper kontrol;
        Student ogrenci;
        private void btnInsert_Click(object sender, EventArgs e)
        {
            kontrol = new ToolHelper();

            if (kontrol.BosAlanKontrol(this))
            {
                ogrenci = new Student()
                {
                    FirstName = txtName.Text,
                    LastName = txtLastName.Text,
                    BirthDate = dtpBirthDate.Value
                };

                ResultModel<Student> result = _unitOfWork.Students.Insert(ogrenci);
                if (result.IsSuccess)
                {
                    GetAll();
                    ButtonDefault();
                    ToolHelper.TextTemizle(this);
                    ogrenci = null;
                }
                MessageBox.Show(result.Message);
            }
            


        }


        void ButtonDefault()
        {
            btnInsert.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        void ButtonUpdateDelete()
        {
            btnInsert.Enabled = false;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            ogrenci = (Student)listView1.SelectedItems[0].Tag;
            if (ogrenci != null)
            {
                ButtonUpdateDelete();
                txtName.Text = ogrenci.FirstName;
                txtLastName.Text = ogrenci.LastName;
                dtpBirthDate.Value = ogrenci.BirthDate;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            kontrol = new ToolHelper();

            if (kontrol.BosAlanKontrol(this))
            {
                ogrenci.FirstName = txtName.Text;
                ogrenci.LastName = txtLastName.Text;
                ogrenci.BirthDate = dtpBirthDate.Value;

                ResultModel<Student> result = _unitOfWork.Students.Update(ogrenci);
                if (result.IsSuccess)
                {
                    GetAll();
                    ButtonDefault();
                    ToolHelper.TextTemizle(this);
                    ogrenci = null;
                }
                MessageBox.Show(result.Message);
            }
                    

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ResultModel<bool> result = _unitOfWork.Students.Delete(ogrenci.Id);
            if (result.IsSuccess)
            {
                ButtonDefault();
                GetAll();
                ogrenci = null;
                ToolHelper.TextTemizle(this);
            }
            MessageBox.Show(result.Message??"Kayıt başarıyla silindi");
        }
    }
}
