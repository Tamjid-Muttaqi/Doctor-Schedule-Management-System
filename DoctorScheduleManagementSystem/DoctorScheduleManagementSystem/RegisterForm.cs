using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DoctorScheduleManagementSystem
{
    public class RegisterForm : Form
    {
        TextBox txtName, txtUsername, txtPassword, txtEmail, txtPhone;
        public RegisterForm()
        {
            Text="User Registration"; Size=new Size(480,430); StartPosition=FormStartPosition.CenterScreen;
            Controls.Add(new Label{Text="Patient Registration",Font=new Font("Arial",18,FontStyle.Bold),AutoSize=true,Location=new Point(110,25)});
            txtName=AddTextBox("Full Name",85); txtUsername=AddTextBox("Username",130); txtPassword=AddTextBox("Password",175); txtPassword.PasswordChar='*'; txtEmail=AddTextBox("Email",220); txtPhone=AddTextBox("Phone",265);
            Button btnSave = new Button{Text="Register",Location=new Point(190,325),Width=100}; btnSave.Click += BtnSave_Click; Controls.Add(btnSave);
        }
        TextBox AddTextBox(string label, int y){ Label l=new Label{Text=label,Location=new Point(75,y+5),AutoSize=true}; TextBox t=new TextBox{Location=new Point(180,y),Width=200}; Controls.Add(l); Controls.Add(t); return t; }
        void BtnSave_Click(object sender, EventArgs e)
        {
            if(txtName.Text.Trim()=="" || txtUsername.Text.Trim()=="" || txtPassword.Text.Trim()==""){ MessageBox.Show("Full name, username and password are required."); return; }
            bool ok=Db.Execute(@"INSERT INTO Users(FullName,Username,Password,Email,Phone,Role) VALUES(@n,@u,@p,@e,@ph,'User')", new SqlParameter("@n",txtName.Text.Trim()), new SqlParameter("@u",txtUsername.Text.Trim()), new SqlParameter("@p",txtPassword.Text.Trim()), new SqlParameter("@e",txtEmail.Text.Trim()), new SqlParameter("@ph",txtPhone.Text.Trim()));
            if(ok){ MessageBox.Show("Registration successful."); Close(); }
        }
    }
}
