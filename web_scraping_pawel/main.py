import requests
from bs4 import BeautifulSoup
from selenium import webdriver
from selenium.webdriver.chrome.service import Service
from selenium.webdriver.chrome.options import Options

##options
chrome_options = Options()
chrome_options.add_argument("--headless")
chrome_options.add_argument("--no-sandbox")

service = Service("C:\pawel_workspace\web_scraping\chromedriver\chromedriver.exe")
driver = webdriver.Chrome(service=service, options=chrome_options)
URL = "https://www.meetup.com/pl-PL/find/?location=pl--Wroclaw&source=EVENTS&eventType=inPerson"


def get_html(url):
    driver.get(url)
    content = driver.page_source
    # print(content)'
    soup = BeautifulSoup(content, features='html.parser')
    return soup


# print(list(body.children))

wroclaw_events_content = get_html(URL)
event_cards = wroclaw_events_content.find_all('a', id='event-card-in-search-results')
event_links = []
for card in event_cards:
    event_link = card.get('href')
    event_links.append(event_link)

sample_event = ''
print(len(event_links))
for link in event_links:
    # print(link)
    if '282122167' in link:
        sample_event = link
        # print(sample_event)

event_content = get_html(sample_event)

title = event_content.find('title').string  # event title
date = event_content.find('span', class_="eventTimeDisplay-startDate").string  # event date
start_time = event_content.find('span', class_="eventTimeDisplay-startDate-time").string  # event start time
time_list = event_content.find_all('span', class_="eventTimeDisplay-endDate-partialTime")
end_time = (time_list[0].find_all('span')[0]).string  # event end time
time_zone = (time_list[0].find_all('span')[1]).string  # event time zone

location_list = event_content.find_all('p', class_="wrap--singleLine--truncate")
location = location_list[0].string  # event location

district = event_content.find('p', class_="venueDisplay-venue-address").getText()  # event district

description = event_content.find('div', class_="event-description runningText").getText()  # event description

coordinates = event_content.find('a', class_="venueMap-mapLink").get('href')
start_index = coordinates.find('query=') + len('query=')
end_index = coordinates.find('%')

latitude = coordinates[start_index:end_index]  # event latitude
longitude = coordinates[end_index + 3:]  # event longitude
