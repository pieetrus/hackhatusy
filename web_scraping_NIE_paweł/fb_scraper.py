import requests
import bs4
from bs4 import BeautifulSoup
from selenium import webdriver
from selenium.webdriver.chrome.service import Service
from selenium.webdriver.chrome.options import Options
import time
import re

##options
chrome_options = Options()
#chrome_options.add_argument("--headless")
chrome_options.add_argument("--no-sandbox")

facebook_event_link = 'https://www.facebook.com/events/'
s = Service('D:/chromedriver.exe')
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
event_ids = []
for a in aaa:
    #links = aaa.findAll('href')
    event_links = a.get('href')
    event_ids_tmp = re.findall('[0-9]*', event_links)
    for event_id in event_ids_tmp:
        if len(event_id) > 3:
            print(event_id)
            event_ids.append(event_id)

for event_id in event_ids:
    event_link = facebook_event_link + event_id
    driver.get(event_link)
    event_content = driver.page_source
    event_soup = BeautifulSoup(event_content, 'html.parser')
    print(event_soup)