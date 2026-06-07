using DataSimulatorApp.Helpers;
using DataSimulatorApp.Models;
using DataSimulatorApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DataSimulatorApp.ViewModels;

public class CreateSampleViewModel
{
    private readonly ISampleService _sampleService;

    public SampleRequest Sample { get; set; }

    public ICommand SaveCommand { get; }

    public CreateSampleViewModel()
    {
        _sampleService =
            new SampleApiService();

        Sample =
            new SampleRequest();

        SaveCommand =
            new RelayCommand(RegisterSampleAsync);
    }

    private async Task RegisterSampleAsync()
    {
        bool success =
            await _sampleService
                .CreateSampleAsync(Sample);

        if (success)
        {
            MessageBox.Show(
                "Sample registered successfully.");
        }
        else
        {
            MessageBox.Show(
                "Error registering sample.");
        }
    }
}