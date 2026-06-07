using System;

namespace DataSimulatorApp.Models;

public class SampleRequest
{
    public int SampleCode { get; set; }

    public string ProteinName { get; set; } = string.Empty;

    public DateTime CaptureDate { get; set; }  = DateTime.Now;

    public double GravityLevel { get; set; }

    public double Temperature { get; set; }

    public double MechanicalVibration { get; set; }

    public string ImagePath { get; set; } = string.Empty;
}