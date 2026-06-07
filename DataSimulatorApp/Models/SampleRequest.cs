using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSimulatorApp.Models;
    public class SampleRequest
    {
        public string SampleCode { get; set; }

        public string ProteinName { get; set; }

        public DateTime CaptureDate { get; set; }

        public int IncubationPeriod { get; set; }

        public double GravityLevel { get; set; }

        public double Temperature { get; set; }

        public double MechanicalVibration { get; set; }

        public string ImagePath { get; set; }
    }
