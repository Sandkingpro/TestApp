
using Microsoft.JSInterop;
namespace TestApp;

public class LocalStorage
{
    private IJSObjectReference? module;
    private IJSRuntime JS;

    public LocalStorage(IJSRuntime js)
    {
        JS = js;
        callJs();
    }

    private async void callJs()
    { ;
        module = await JS.InvokeAsync<IJSObjectReference>(
            "import", "./LocalStorage.js");
    }

    public async Task setItem(string? key,string? value)
    {
        if (value != null & key != null)
        {
            if (!value.Equals("") & !key.Equals(""))
            {
                await setValue(key,value);
            }
        }
        
    }
    private async ValueTask<string?> setValue(string key,string message) =>
        module is not null ? 
            await module.InvokeAsync<string>("setItem", key,message) : null;

    public async Task<string?> getItem(string? key)
    {
        if (key != null)
        {
            if (!key.Equals(""))
            {
                return await getValue(key);
            } 
        }
        
        return "key is null";
    }

    private async ValueTask<string?> getValue(string key) =>
        module is not null ? await module.InvokeAsync<string>("getItem", key) : null;

    public async Task removeItem(string? key)
    {
        if (key != null)
        {
            if (!key.Equals(""))
            {
                await remove(key);
            }
        }
       
    }

    private async ValueTask<string?> remove(string key) =>
        module is not null ? await module.InvokeAsync<string>("remove", key) : null;

    public async Task Clear()
    {
        await clear();
    }

    private async ValueTask<string?> clear() =>
        module is not null ? await module.InvokeAsync<string>("Clear") : null;

}
    