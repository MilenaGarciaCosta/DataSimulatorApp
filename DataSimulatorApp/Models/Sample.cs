using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSimulatorApp.Models;
    class Sample
    {
        public int Id { get; set; }
        public int SampleId { get; set; }
        public string ProteinName { get; set; }
        public DateTime CaptureDate { get; set; }
        public Decimal GravityLevel { get; set; }
        public Decimal Temperature { get; set; }
        public Decimal MechanicalVibration { get; set; }
        public string ImagePath { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
}
