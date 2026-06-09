using DataSimulatorApp.Helpers;
using DataSimulatorApp.Models;
using DataSimulatorApp.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace DataSimulatorApp.ViewModels;
public class SampleListViewModel : INotifyPropertyChanged
{
    private readonly ISampleService _sampleService;

    public ObservableCollection<SampleResponse> Samples{ get; set; }
    private bool _isLoading;

    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            _isLoading = value;
            OnPropertyChanged();
        }
    }

    public ICommand RefreshCommand { get; }

    public SampleListViewModel()
    {
        _sampleService = new SampleApiService();

        Samples = new ObservableCollection<SampleResponse>();

        RefreshCommand = new RelayCommand(LoadSamplesAsync);
        _ = LoadSamplesAsync();
    }

    private async Task LoadSamplesAsync()
    {
        try
        {
            IsLoading = true;

            Samples.Clear();

            var sampleList = await _sampleService.GetSamplesAsync();

            foreach (var sample in sampleList)
            {
                Samples.Add(sample);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading samples.\n\n{ex.Message}");
        }
        finally
        {
            IsLoading = false;
        }
    }

    public event PropertyChangedEventHandler?
        PropertyChanged;

    private void OnPropertyChanged(
        [CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(
            this, new PropertyChangedEventArgs(propertyName));
    }
}
