using System.Drawing;
using System.Windows.Forms;
namespace DoctorScheduleManagementSystem
{
    public class PaymentHistoryForm : Form
    {
        DataGridView grid;
        public PaymentHistoryForm(){Text="Payment History";Size=new Size(950,500);StartPosition=FormStartPosition.CenterScreen;Label title=new Label{Text="Payment History",Font=new Font("Arial",18,FontStyle.Bold),AutoSize=true,Location=new Point(360,25)};grid=new DataGridView{Location=new Point(40,90),Size=new Size(850,320),ReadOnly=true,AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill};Button btnRefresh=new Button{Text="Refresh",Location=new Point(410,425),Width=120};btnRefresh.Click+=(s,e)=>LoadPayments();Controls.AddRange(new Control[]{title,grid,btnRefresh});LoadPayments();}
        void LoadPayments(){grid.DataSource=Db.GetData(@"SELECT p.PaymentId,p.AppointmentId,u.FullName AS PatientName,d.DoctorName,p.Amount,p.CouponCode,p.CaseType,p.DiscountAmount,p.FinalAmount,p.PaymentMethod,p.PaymentStatus,p.PaymentDate FROM Payments p INNER JOIN Appointments a ON p.AppointmentId=a.AppointmentId INNER JOIN Users u ON a.UserId=u.UserId INNER JOIN Doctors d ON a.DoctorId=d.DoctorId ORDER BY p.PaymentId DESC");}
    }
}
