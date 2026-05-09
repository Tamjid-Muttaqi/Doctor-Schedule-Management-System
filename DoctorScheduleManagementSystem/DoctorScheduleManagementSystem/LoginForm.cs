using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DoctorScheduleManagementSystem
{
    public class LoginForm : Form
    {
        TextBox txtUsername, txtPassword;
        public LoginForm()
        {
            Text = "Doctor Schedule Management System - Login"; Size = new Size(460,350); StartPosition = FormStartPosition.CenterScreen;
            Label title = new Label { Text="Login", Font=new Font("Arial",20,FontStyle.Bold), AutoSize=true, Location=new Point(185,35)};
            Label user = new Label { Text="Username", Location=new Point(70,110), AutoSize=true};
            Label pass = new Label { Text="Password", Location=new Point(70,160), AutoSize=true};
            txtUsername = new TextBox { Location=new Point(170,105), Width=190};
            txtPassword = new TextBox { Location=new Point(170,155), Width=190, PasswordChar='*'};
            Button btnLogin = new Button { Text="Login", Location=new Point(170,215), Width=85};
            Button btnRegister = new Button { Text="Register", Location=new Point(275,215), Width=85};
            btnLogin.Click += BtnLogin_Click; btnRegister.Click += (s,e)=> new RegisterForm().ShowDialog();
            Controls.AddRange(new Control[]{title,user,pass,txtUsername,txtPassword,btnLogin,btnRegister});
        }
        void BtnLogin_Click(object sender, EventArgs e)
        {
            DataTable dt = Db.GetData("SELECT TOP 1 * FROM Users WHERE Username=@u AND Password=@p", new SqlParameter("@u", txtUsername.Text.Trim()), new SqlParameter("@p", txtPassword.Text.Trim()));
            if (dt.Rows.Count == 0) { MessageBox.Show("Invalid username or password."); return; }
            AppSession.UserId = Convert.ToInt32(dt.Rows[0]["UserId"]); AppSession.FullName = dt.Rows[0]["FullName"].ToString(); AppSession.Role = dt.Rows[0]["Role"].ToString();
            Hide();
            if (AppSession.Role == "SuperAdmin") new SuperAdminDashboardForm().ShowDialog();
            else if (AppSession.Role == "Admin") new AdminDashboardForm().ShowDialog();
            else new UserDashboardForm().ShowDialog();
            AppSession.Clear(); txtPassword.Clear(); Show();
        }
    }
}
