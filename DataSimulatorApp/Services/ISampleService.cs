using DataSimulatorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSimulatorApp.Services;
    public interface ISampleService
    {
        Task<bool> CreateSampleAsync(SampleRequest request);

        Task<List<SampleResponse>>GetSamplesAsync();
    }
