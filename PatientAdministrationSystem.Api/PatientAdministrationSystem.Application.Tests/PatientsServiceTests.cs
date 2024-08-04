using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using PatientAdministrationSystem.Application.Entities;
using PatientAdministrationSystem.Application.Repositories.Interfaces;
using PatientAdministrationSystem.Application.Services;

namespace PatientAdministrationSystem.Application.Tests;

public class PatientsServiceTests
{
    private readonly IFixture _fixture;
    private readonly PatientsService _subject;
    private readonly Mock<IPatientsRepository> _patientsRepositoryMock;

    public PatientsServiceTests()
    {
        
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        
        _patientsRepositoryMock = new Mock<IPatientsRepository>();
        _subject = new PatientsService(_patientsRepositoryMock.Object);
    }
    
    [Fact]
    public async Task RetrievePatientAsync_when_no_patients_are_found_then_return_emptyList()
    {
        // ARRANGE
        const string testEmail = "test@email.com";
        _patientsRepositoryMock.Setup(t => t.RetrievePatientAsync(It.IsAny<string>(), CancellationToken.None))
            .ReturnsAsync(new List<PatientEntity>());
        
        // ACT
        var result = await _subject.FindPatientVisitsByEmailAsync(testEmail, CancellationToken.None);
        
        // ASSERT
        Assert.Empty(result);
        _patientsRepositoryMock.Verify(t=> t.RetrievePatientAsync(It.IsAny<string>(), CancellationToken.None), Times.Once);
    }
    
    [Fact]
    public async Task RetrievePatientAsync_when_patients_are_found_then_return_mappedList()
    {
        // ARRANGE
        const string testEmail = "test@email.com";
        var patientEntities = _fixture.CreateMany<PatientEntity>().ToList();
        _patientsRepositoryMock.Setup(t => t.RetrievePatientAsync(It.IsAny<string>(), CancellationToken.None))
            .ReturnsAsync(patientEntities);
        
        // ACT
        var result = await _subject.FindPatientVisitsByEmailAsync(testEmail, CancellationToken.None);
        
        // ASSERT
        Assert.NotEmpty(result);
    }
}