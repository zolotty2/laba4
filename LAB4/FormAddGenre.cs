using System.ComponentModel;
using AppContext = LAB4.Models.AppContext;

namespace LAB4
{
    public partial class FormAddGenre : Form
    {
        private AppContext db;

        public FormAddGenre()
        {
            InitializeComponent();
            this.db = new AppContext();
        }

        private void TextBoxGenre_TextChanged(object sender, EventArgs e)
        {
            FormAddGenre formAddGenre = new FormAddGenre();
            string newGenreAnime = textBoxGenre.Text;//сохраняем текст в newStatusAnime

            bool exists = db.Genres.Any(t => t.GenreName == newGenreAnime);

            if (exists)
            {
                BtnSaveChanges.Enabled = false;//уходим в ошибку 
                errorProvider1.SetError(textBoxGenre, "Поле должно быть уникальным");

            }
            else
            {
                errorProvider1.Clear();
                BtnSaveChanges.Enabled = true;//пропускаем

            }

            if (String.IsNullOrEmpty(textBoxGenre.Text))
            {
                errorProvider1.SetError(textBoxGenre, "Поле не может быть пустым");
                BtnSaveChanges.Enabled = false;
            }
            else
            {
                errorProvider1.Clear();
                BtnSaveChanges.Enabled = true;
            }
        }

        private void TextBoxGenre_Validating(object sender, CancelEventArgs e)
        {
            FormAddGenre formAddGenre = new FormAddGenre();
            string newGenreAnime = textBoxGenre.Text;//сохраняем текст в newStatusAnime

            bool exists = db.Genres.Any(t => t.GenreName == newGenreAnime);

            if (exists)
            {
                BtnSaveChanges.Enabled = false;//уходим в ошибку 
                errorProvider1.SetError(textBoxGenre, "Поле должно быть уникальным");

            }
            else
            {
                errorProvider1.Clear();
                BtnSaveChanges.Enabled = true;//пропускаем

            }

            if (String.IsNullOrEmpty(textBoxGenre.Text))
            {
                errorProvider1.SetError(textBoxGenre, "Поле не может быть пустым");
                BtnSaveChanges.Enabled = false;
            }
            else
            {
                errorProvider1.Clear();
                BtnSaveChanges.Enabled = true;
            }
        }        
    }
}