import requests
from bs4 import BeautifulSoup
from selenium import webdriver
from selenium.webdriver.chrome.service import Service
from selenium.webdriver.chrome.options import Options
import time

##options
chrome_options = Options()
#chrome_options.add_argument("--headless")
#chrome_options.add_argument("--no-sandbox")


s = Service('./chromedriver.exe')
driver = webdriver.Chrome(service=s, chrome_options=chrome_options)
driver.maximize_window()
driver.get('https://www.facebook.com/events/search/?q=wroc%C5%82aw')
time.sleep(2)
driver.execute_script('window.scrollBy(0,2500)', '')
#driver.find_element_by_xpath('//*[@id="uc-btn-accept-banner"]').click()
content = driver.page_source

#response = requests.get('https://www.facebook.com/events/search/?q=wroc%C5%82aw')
soup = BeautifulSoup(content, 'html.parser')
aaa = soup.find_all('a')
for a in aaa:
    #links = aaa.findAll('href')
    print(a.get('href'))
