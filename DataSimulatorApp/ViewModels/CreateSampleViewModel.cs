using DataSimulatorApp.Helpers;
using DataSimulatorApp.Models;
using DataSimulatorApp.Services;
using Microsoft.Win32;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace DataSimulatorApp.ViewModels;

public class CreateSampleViewModel : INotifyPropertyChanged
{
    private readonly ISampleService _sampleService;

    private string _selectedImagePath = string.Empty;

    private BitmapImage? _previewImage;

    public SampleRequest Sample { get; set; }

    public string SelectedImagePath
    {
        get => _selectedImagePath;
        set
        {
            _selectedImagePath = value;
            OnPropertyChanged();
        }
    }

    public BitmapImage? PreviewImage
    {
        get => _previewImage;
        set
        {
            _previewImage = value;
            OnPropertyChanged();
        }
    }

    public ICommand SaveCommand { get; }

    public ICommand SelectImageCommand { get; }

    public CreateSampleViewModel()
    {
        _sampleService =
            new SampleApiService();

        Sample =
            new SampleRequest();

        SaveCommand =
            new RelayCommand(
                RegisterSampleAsync);

        SelectImageCommand =
            new RelayCommand(
                SelectImageAsync);
    }

    private Task SelectImageAsync()
    {
        OpenFileDialog dialog = new OpenFileDialog();

        dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

        if (dialog.ShowDialog() == true)
        {
            SelectedImagePath =dialog.FileName;

            Sample.ImagePath = dialog.FileName;

            PreviewImage = new BitmapImage(new Uri(dialog.FileName));
        }

        return Task.CompletedTask;
    }

    private async Task RegisterSampleAsync()
    {
        bool success = await _sampleService.CreateSampleAsync(Sample);

        if (success)
        {
            MessageBox.Show("Sample registered successfully.");

            ClearForm();
        }
        else
        {
            MessageBox.Show("Error registering sample.");
        }
    }

    private void ClearForm()
    {
        Sample =new SampleRequest();

        SelectedImagePath = string.Empty;

        PreviewImage = null;

        OnPropertyChanged(nameof(Sample));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(
        [CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(
            this, new PropertyChangedEventArgs(propertyName));
    }
}