using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSimulatorApp.Models;
    public class SampleResponse
    {
        public long Id { get; set; }

        public string SampleCode { get; set; }

        public string ProteinName { get; set; }

        public string Status { get; set; }

        public string Classification { get; set; }

        public double Confidence { get; set; }

        public string ImageUrl { get; set; }
    }
