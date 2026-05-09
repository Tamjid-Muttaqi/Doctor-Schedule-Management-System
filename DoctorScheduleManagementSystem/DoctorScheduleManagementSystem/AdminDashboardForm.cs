using System.Drawing;
using System.Windows.Forms;
namespace DoctorScheduleManagementSystem
{
    public class AdminDashboardForm : Form
    {
        public AdminDashboardForm()
        {
            Text="Admin Dashboard"; Size=new Size(540,400); StartPosition=FormStartPosition.CenterScreen;
            Label title=new Label{Text="Admin Dashboard",Font=new Font("Arial",18,FontStyle.Bold),AutoSize=true,Location=new Point(160,35)};
            Button btnDoctor=new Button{Text="Manage Doctors",Location=new Point(170,100),Width=190,Height=38}; btnDoctor.Click+=(s,e)=>new DoctorManagementForm().ShowDialog();
            Button btnSchedule=new Button{Text="Manage Schedule",Location=new Point(170,155),Width=190,Height=38}; btnSchedule.Click+=(s,e)=>new ScheduleManagementForm().ShowDialog();
            Button btnPayment=new Button{Text="Payment History",Location=new Point(170,210),Width=190,Height=38}; btnPayment.Click+=(s,e)=>new PaymentHistoryForm().ShowDialog();
            Button btnLogout=new Button{Text="Logout",Location=new Point(170,280),Width=190,Height=38}; btnLogout.Click+=(s,e)=>Close();
            Controls.AddRange(new Control[]{title,btnDoctor,btnSchedule,btnPayment,btnLogout});
        }
    }
}
