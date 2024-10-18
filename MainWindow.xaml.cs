using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ContractMonthlyClaimSystem
{
    public partial class MainWindow : Window
    {
        private List<Claim> claims;

        public MainWindow()
        {
            InitializeComponent();
            LoadClaims();
        }

        private void LoadClaims()
        {
            claims = new List<Claim>
            {
                new Claim { LecturerName = "John Doe", HoursWorked = 40, HourlyRate = 50, TotalAmount = 2000, Status = "Pending" },
                new Claim { LecturerName = "Jane Smith", HoursWorked = 35, HourlyRate = 45, TotalAmount = 1575, Status = "Pending" }
            };
            claimsListView.ItemsSource = claims;
        }

        private void SubmitClaimButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string hoursWorked = hoursWorkedTextBox.Text;
                string hourlyRate = hourlyRateTextBox.Text;

                if (string.IsNullOrEmpty(hoursWorked) || string.IsNullOrEmpty(hourlyRate))
                {
                    MessageBox.Show("Please enter hours worked and hourly rate.");
                    return;
                }

                int hours = int.Parse(hoursWorked);
                double rate = double.Parse(hourlyRate);
                var totalAmount = hours * rate;

                var newClaim = new Claim
                {
                    LecturerName = "New Lecturer", // You can adjust this to get the actual lecturer name
                    HoursWorked = hours,
                    HourlyRate = rate,
                    TotalAmount = totalAmount,
                    Status = "Pending"
                };

                claims.Add(newClaim);
                claimsListView.Items.Refresh();
                MessageBox.Show("Claim submitted successfully!");

                // Clear form fields after submission
                hoursWorkedTextBox.Clear();
                hourlyRateTextBox.Clear();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers for hours worked and hourly rate.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ApproveClaimButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedClaim = claimsListView.SelectedItem as Claim;
            if (selectedClaim != null)
            {
                selectedClaim.Approve();
                claimsListView.Items.Refresh();
                MessageBox.Show($"Claim by {selectedClaim.LecturerName} approved.");
            }
        }

        private void RejectClaimButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedClaim = claimsListView.SelectedItem as Claim;
            if (selectedClaim != null)
            {
                selectedClaim.Reject();
                claimsListView.Items.Refresh();
                MessageBox.Show($"Claim by {selectedClaim.LecturerName} rejected.");
            }
        }

        private void TrackClaimButton_Click(object sender, RoutedEventArgs e)
        {
            string lecturerNameToTrack = lecturerNameToTrackTextBox.Text;

            var claimToTrack = claims.FirstOrDefault(c => c.LecturerName.Equals(lecturerNameToTrack, StringComparison.OrdinalIgnoreCase));

            if (claimToTrack != null)
            {
                claimStatusLabel.Text = $"Claim Status: {claimToTrack.Status}";
            }
            else
            {
                claimStatusLabel.Text = "No claim found for the given lecturer.";
            }
        }
    }

    public class Claim
    {
        public string LecturerName { get; set; }
        public int HoursWorked { get; set; }
        public double HourlyRate { get; set; }
        public double TotalAmount { get; set; }
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
}
