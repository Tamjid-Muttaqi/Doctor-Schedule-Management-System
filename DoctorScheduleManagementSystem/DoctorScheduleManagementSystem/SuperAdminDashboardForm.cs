using System.Drawing;
using System.Windows.Forms;
namespace DoctorScheduleManagementSystem
{
    public class SuperAdminDashboardForm : Form
    {
        public SuperAdminDashboardForm()
        {
            Text="Super Admin Dashboard"; Size=new Size(570,420); StartPosition=FormStartPosition.CenterScreen;
            Label title=new Label{Text="Super Admin Dashboard",Font=new Font("Arial",18,FontStyle.Bold),AutoSize=true,Location=new Point(130,35)};
            Button btnReview=new Button{Text="Public Reviews / Remove Doctor",Location=new Point(155,105),Width=245,Height=40}; btnReview.Click+=(s,e)=>new ReviewManagementForm().ShowDialog();
            Button btnDoctor=new Button{Text="View Doctors",Location=new Point(155,165),Width=245,Height=40}; btnDoctor.Click+=(s,e)=>new DoctorManagementForm(true).ShowDialog();
            Button btnPayment=new Button{Text="View Payments",Location=new Point(155,225),Width=245,Height=40}; btnPayment.Click+=(s,e)=>new PaymentHistoryForm().ShowDialog();
            Button btnLogout=new Button{Text="Logout",Location=new Point(155,290),Width=245,Height=40}; btnLogout.Click+=(s,e)=>Close();
            Controls.AddRange(new Control[]{title,btnReview,btnDoctor,btnPayment,btnLogout});
        }
    }
}
