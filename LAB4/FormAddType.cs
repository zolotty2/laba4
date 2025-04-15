using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB4
{
    public partial class FormAddType : Form
    {
        public FormAddType()

        {
            InitializeComponent();
        }

        private void FormAddType_Load(object sender, EventArgs e)
        {

        }

        private void textBoxType_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxTypes.Text))
            {
                errorProvider.SetError(textBoxTypes, "Поле не может быть пустым");
                BtnSaveChanges.Enabled = false;
            }
            else
            {
                errorProvider.Clear();
                BtnSaveChanges.Enabled = true;
            }
        }
        private void nameBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxTypes.Text))
            {
                errorProvider.SetError(textBoxTypes, "Поле не может быть пустым");
                BtnSaveChanges.Enabled = false;
            }
            else
            {
                errorProvider.Clear();
                BtnSaveChanges.Enabled = true ;
            }
        }
    }
}
