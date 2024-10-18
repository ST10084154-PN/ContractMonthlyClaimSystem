public class Claim
{
    public string LecturerName { get; set; }
    public int HoursWorked { get; set; }
    public double HourlyRate { get; set; }
    public double TotalAmount => HoursWorked * HourlyRate; // Calculate total amount based on hours and rate
    public string Status { get; set; } = "Pending";

    public void Approve()
    {
        Status = "Approved";
    }

    public void Reject()
    {
        Status = "Rejected";
    }
}
