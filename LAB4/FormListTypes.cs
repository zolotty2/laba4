using LAB4.Models;
using Microsoft.EntityFrameworkCore;
using AppContext = LAB4.Models.AppContext;

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
            this.dataGridViewTypes.DataSource =this.db.Types.Local.OrderBy(o=>o.TypeName).ToList();

            dataGridViewTypes.Columns["id"].Visible = false;
            dataGridViewTypes.Columns["AnimeTitles"].Visible = false;

            dataGridViewTypes.Columns["TypeName"].HeaderText = "Тип аниме";
        }

        private void BtnAddType_Click(object sender, EventArgs e)
        {
            FormAddType formAddType = new FormAddType();
            formAddType.ShowDialog();
        }
    }
}
