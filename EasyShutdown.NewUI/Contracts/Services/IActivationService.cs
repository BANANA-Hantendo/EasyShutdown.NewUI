namespace EasyShutdown.NewUI.Contracts.Services;

public interface IActivationService
{
    Task ActivateAsync(object activationArgs);
}
