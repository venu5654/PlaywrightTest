using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightTests;
public class UnitTest1
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1()
    {
        //Playwright
        using var playwright = await Playwright.CreateAsync();
        
        //Browser
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });

        //page
        var page = await browser.NewPageAsync();
        await page.GotoAsync(url:"http://eaapp.somee.com");
        await page.ClickAsync(selector:"text=Login");
        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "click.jpg"
        });//Task<byte[]>
        await page.FillAsync(selector:"#UserName", value:"admin");
        await page.FillAsync(selector:"#Password", value:"password");        
        await page.ClickAsync(selector:"text=Log in");
        var isExist = await page.Locator(selector:"text='Employee Details'").IsVisibleAsync();
        Assert.IsTrue(isExist);
    }
}