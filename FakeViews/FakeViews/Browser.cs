using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace FakeViews
{
	public class Browser
	{
		private string url;
		private ChromeDriverService service;
		private ChromeOptions options;
		private ChromeDriver driver;

		private List<IWebElement> botoes;
		private IWebElement currentsong;
		public int Count
		{
			get
			{
				return botoes.Count;
			}
		}
		public IWebElement CurrentSong
		{
			get
			{
				return currentsong;
			}
		}

		public Browser(string Url,bool type = true)
		{
			this.url = Url;
			this.botoes = new List<IWebElement>();
			this.HideBrowser(type);
			driver.Navigate().GoToUrl(url);
			this.GetPlayButton();
		}
		~Browser()
		{
			this.Close();
		}
		public void Close()
		{
			driver.Close();
			driver.Quit();
		}



		public void Play(int id)
		{
			try
			{
				botoes[id].Click();
				currentsong = botoes[id];
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.Message);
			}
		}


		private void HideBrowser(bool hide = true)
		{
			service = ChromeDriverService.CreateDefaultService();
			options = new ChromeOptions();
			service.HideCommandPromptWindow = true;
			options.AddArgument("--window-position=-32000,-32000");
			if (hide)
				driver = new ChromeDriver(service, options);
			else
				driver = new ChromeDriver();
		}

		private void GetPlayButton()
		{
			var temp = driver.FindElements(By.TagName("button")).
							 Where(x => x.GetAttribute("title").Equals("Play")
							 && x.GetAttribute("class").Equals("sc-button-play playButton sc-button sc-button-xlarge"));
			botoes.AddRange(temp);
		}
	}
}
