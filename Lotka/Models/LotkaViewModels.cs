using System.ComponentModel.DataAnnotations;

namespace Lotka.Models
{
    public class QuoteRequestModel
    {
        [Required(ErrorMessage = "Origin is required")]
        public string Origin { get; set; } = string.Empty;

        [Required(ErrorMessage = "Destination is required")]
        public string Destination { get; set; } = string.Empty;

        [Required(ErrorMessage = "Freight mode is required")]
        public string FreightType { get; set; } = "Air"; // Air, Ocean, Land

        [Range(1, 100000, ErrorMessage = "Weight must be between 1 and 100,000 kg")]
        public double WeightKg { get; set; } = 150;

        public string CargoType { get; set; } = "General Cargo";

        public string? Email { get; set; }

        public string? FullName { get; set; }

        public string? Phone { get; set; }
    }

    public class ContactRequestModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Valid email is required")]
        public string Email { get; set; } = string.Empty;

        public string? Phone { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        public string Subject { get; set; } = string.Empty;

        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; } = string.Empty;
    }

    public class ShipmentTrackingResult
    {
        public string TrackingNumber { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Origin { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public string EstimatedDelivery { get; set; } = string.Empty;
        public string CurrentLocation { get; set; } = string.Empty;
        public string Carrier { get; set; } = string.Empty;
        public List<TrackingCheckpoint> Checkpoints { get; set; } = new();
    }

    public class TrackingCheckpoint
    {
        public string Timestamp { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}
