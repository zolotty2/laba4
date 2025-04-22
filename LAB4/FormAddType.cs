﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppContext = LAB4.Models.AppContext;
namespace LAB4
{
public partial class FormAddType : Form
{
    private AppContext db;
    public FormAddType()

    {
        InitializeComponent();
        this.db = new AppContext();
    }

    private void FormAddType_Load(object sender, EventArgs e)
    {

    }

    private void textBoxType_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxStatus.Text))
            {
                errorProvider.SetError(textBoxStatus, "Поле не может быть пустым");
                BtnSaveChanges.Enabled = false;
            }
            else
            {
                errorProvider.Clear();
                BtnSaveChanges.Enabled = true;
            }
            FormAddType formAddType = new FormAddType();
            string newTypeAnime = textBoxStatus.Text;//сохраняем текст в newStatusAnime

            bool exists = db.Types.Any(t => t.TypeName == newTypeAnime);
            //сраваниваем newStatusAnime с бд если есть совпадения то true



            if (exists)
            {
                BtnSaveChanges.Enabled = false;//уходим в ошибку 
                errorProvider.SetError(textBoxStatus, "Поле должно быть уникальным");

            }
            else
            {
                errorProvider.Clear();
                BtnSaveChanges.Enabled = true;//пропускаем

            }
        }
    private void nameBox_Validating(object sender, CancelEventArgs e)
    {
        if (String.IsNullOrEmpty(textBoxStatus.Text))
        {
            errorProvider.SetError(textBoxStatus, "Поле не может быть пустым");
            BtnSaveChanges.Enabled = false;
        }
        else
        {
            errorProvider.Clear();
            BtnSaveChanges.Enabled = true;
        }
    }
            
    }
}


