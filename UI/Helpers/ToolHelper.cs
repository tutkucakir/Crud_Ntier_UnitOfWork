using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Helpers
{
    public class ToolHelper
    {

        public static void TextTemizle(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox) ((TextBox)c).Text = String.Empty;
                TextTemizle(c);
            }
        }

        bool sonuc = true;
        public bool BosAlanKontrol(Control control)
        {

            if (sonuc == false)
                return sonuc;

            sonuc = true;

            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                {
                    if (((TextBox)c).Text == "" || ((TextBox)c).Text == String.Empty)
                    {
                        MessageBox.Show("Boş alan bırakmayınız!", "Dikkat!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        sonuc = false;
                        break;
                    }
                }


                BosAlanKontrol(c);
            }



            return sonuc;

        }


    }
}
