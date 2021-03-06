﻿using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorNotifier.Classes;
using Microsoft.Extensions.Logging;

namespace BlazorNotifier.Services.Implementations
{
    public class BlazorNotifierServerService
    {
        private readonly ILogger<BlazorNotifierServerService> _Logger;

        public BlazorNotifierServerService(ILogger<BlazorNotifierServerService> Logger)
        {
            _Logger = Logger;
        }

        #region Implementation of IBlazorNotifierServerService

        public async Task<bool> SendNotificationAsync(BlazorNotifierMessage message)
        {
            try
            {
                using var response = await new HttpClient().PostAsJsonAsync("https://localhost:44303/api/notifications/SendMessage", message);
                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                _Logger.LogError("Ошибка отправки сообщения на сервер: {error}", e.Message);
                return false;
            }
        }
        public async Task<bool> SendNotificationAsync(string Title)
        {
            try
            {
                using var response = await new HttpClient().PostAsJsonAsync("https://localhost:44303/api/notifications/SendTitle", Title);
                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                _Logger.LogError("Ошибка отправки сообщения на сервер: {error}", e.Message);
                return false;
            }
        }
        #endregion
    }
}
