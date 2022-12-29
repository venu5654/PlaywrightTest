using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using Microsoft.Playwright.Core;
using NUnit.Framework;
namespace PlaywrightTests;

public class NunitPlayWright:PageTest
{
    [SetUp]
    public async Task Setup()
    {
        await Page.GotoAsync(url:"http://eaapp.somee.com");
    }

    [Test]
    public async Task Test1()
    {
        var lnkLogin = Page.Locator(selector:"text=Login");
        await lnkLogin.ClickAsync();
        await Page.ClickAsync(selector:"text=Login");
        await Page.FillAsync(selector:"#UserName", value:"admin");
        await Page.FillAsync(selector:"#Password", value:"password");        
        await Page.ClickAsync(selector:"text=Log in");
        await Expect(Page.Locator(selector:"text='Employee Details'")).ToBeVisibleAsync();
    }
}