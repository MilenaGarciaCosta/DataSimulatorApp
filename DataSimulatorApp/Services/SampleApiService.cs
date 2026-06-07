using DataSimulatorApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DataSimulatorApp.Services;
public class SampleApiService : ISampleService
{
    private readonly HttpClient _httpClient;

    public SampleApiService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress =
            new Uri("http://localhost:8080/api");
    }

    public async Task<bool> CreateSampleAsync(SampleRequest request)
    {
        using var content =
            new MultipartFormDataContent();

        content.Add(
            new StringContent(request.SampleCode),
            "sampleCode");

        content.Add(
            new StringContent(request.ProteinName),
            "proteinName");

        content.Add(
            new StringContent(
                request.CaptureDate.ToString("o")),
            "captureDate");

        content.Add(
            new StringContent(
                request.IncubationPeriod.ToString()),
            "incubationPeriod");

        content.Add(
            new StringContent(
                request.GravityLevel.ToString()),
            "gravityLevel");

        content.Add(
            new StringContent(
                request.Temperature.ToString()),
            "temperature");

        content.Add(
            new StringContent(
                request.MechanicalVibration.ToString()),
            "mechanicalVibration");

        byte[] imageBytes =
            await File.ReadAllBytesAsync(
                request.ImagePath);

        var imageContent =
            new ByteArrayContent(imageBytes);

        content.Add(
            imageContent,
            "image",
            Path.GetFileName(
                request.ImagePath));

        var response =
            await _httpClient.PostAsync(
                "/samples",
                content);

        return response.IsSuccessStatusCode;
    }

    public async Task<List<SampleResponse>>
        GetSamplesAsync()
    {
        return await _httpClient
            .GetFromJsonAsync<List<SampleResponse>>
                ("/samples")
            ?? new List<SampleResponse>();
    }
}
