public class ClaimModel
{
    public int ClaimId { get; set; }
    public string LecturerName { get; set; }
    public decimal HoursWorked { get; set; }
    public decimal HourlyRate { get; set; }
    public string Notes { get; set; }
    public DateTime DateSubmitted { get; set; }
    public string Status { get; set; }  // Pending, Approved, Rejected
}
