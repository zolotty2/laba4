using System.ComponentModel;
using LAB4.Models;
using Microsoft.EntityFrameworkCore;
using AppContext = LAB4.Models.AppContext;
using Type = LAB4.Models.Type;

namespace LAB4
{
    public partial class FormListTypes : Form
    {
        private AppContext db;
        public FormListTypes()
        {
            InitializeComponent();
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.db = new AppContext();
            this.db.Types.Load();
            this.dataGridViewTypes.DataSource = this.db.Types.Local.OrderBy(o => o.TypeName).ToList();

            dataGridViewTypes.Columns["id"].Visible = false;
            dataGridViewTypes.Columns["AnimeTitles"].Visible = false;

            dataGridViewTypes.Columns["TypeName"].HeaderText = "Тип аниме";
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            this.db?.Dispose();
            this.db = null;

        }
        private void BtnAddType_Click(object sender, EventArgs e)
        {
            FormAddType formAddType = new();
            DialogResult result = formAddType.ShowDialog(this);

            if (result == DialogResult.Cancel)
            {
                return;

                Type type = new Type();
                type.TypeName=formAddType.textBoxTypes.Text;
                db.Types.Add(type);
                db.SaveChanges();

                MessageBox.Show("Новый объект добавлен");

                this.dataGridViewTypes.DataSource = this.db.Types.Local.OrderBy(o => o.TypeName).ToList();
            }
        }
    }
}
