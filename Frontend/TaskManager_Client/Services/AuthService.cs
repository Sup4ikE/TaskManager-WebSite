using Blazored.LocalStorage;

namespace TaskManager_Client.Services;

public class AuthService
{
    private readonly ILocalStorageService _localStorage;

    private const string AccessTokenKey = "accessToken";
    private const string RefreshTokenKey = "refreshToken";

    public AuthService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task SetAuthDataAsync(string accessToken, string refreshToken)
    {
        await _localStorage.SetItemAsync(AccessTokenKey, accessToken);
        await _localStorage.SetItemAsync(RefreshTokenKey, refreshToken);
    }

    public async Task ClearAuthDataAsync()
    {
        await _localStorage.RemoveItemAsync(AccessTokenKey);
        await _localStorage.RemoveItemAsync(RefreshTokenKey);
    }

    public async Task<string?> GetAccessTokenAsync() => await _localStorage.GetItemAsync<string>(AccessTokenKey);

    public async Task<string?> GetRefreshTokenAsync() => await _localStorage.GetItemAsync<string>(RefreshTokenKey);

    public async Task<bool> IsAuthenticatedAsync() => !string.IsNullOrEmpty(await GetAccessTokenAsync());
}
