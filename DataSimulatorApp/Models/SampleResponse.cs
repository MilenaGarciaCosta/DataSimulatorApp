namespace DataSimulatorApp.Models;

public class SampleResponse
{
    public int SampleId { get; set; }

    public string ProteinName { get; set; }

    public DateTime CaptureDate { get; set; }

    public string Status { get; set; }

    public double? Temperature { get; set; }

    public double? GravityLevel { get; set; }

    public double? MechanicalVibration { get; set; }

    public string? ImageUrl { get; set; }

    public int? ExpeditionEfficiencyScore { get; set; }

    public string? RecommendedAction { get; set; }

    public string? Classification { get; set; }

    public double? Confidence { get; set; }

    public DateTime? PredictionDate { get; set; }
}