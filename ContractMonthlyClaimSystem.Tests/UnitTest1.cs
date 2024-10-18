using System.Security.Claims;
using Xunit;

namespace ContractMonthlyClaimSystem.Tests
{
    public class ClaimTests
    {
        [Fact]
        public void SubmitClaim_ShouldSetStatusToPending()
        {
            // Arrange
            var claim = new Claim { LecturerName = "John Doe", HoursWorked = 40, HourlyRate = 50 };

            // Act
            // (No action needed, status is set by default)

            // Assert
            Assert.Equal("Pending", claim.Status);
        }

        [Fact]
        public void ApproveClaim_ShouldSetStatusToApproved()
        {
            // Arrange
            var claim = new Claim();

            // Act
            claim.Approve();

            // Assert
            Assert.Equal("Approved", claim.Status);
        }

        [Fact]
        public void RejectClaim_ShouldSetStatusToRejected()
        {
            // Arrange
            var claim = new Claim();

            // Act
            claim.Reject();

            // Assert
            Assert.Equal("Rejected", claim.Status);
        }
    }
}
