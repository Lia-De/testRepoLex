-- # SQL Join exercise
-- #

-- #
-- # 1: Get the cities with a name starting with ping sorted by their population with the least populated cities first
-- #
select Name, Population from city WHERE NAME LIKE 'Ping%' ORDER BY Population;
Pingyi	89373
Pingliang	99265
Pingdu	150123
Pingchen	188344
Pingtung	214727
Pingdingshan	410775
Pingxiang	425579
-- #
-- # 2: Get the cities with a name starting with ran sorted by their population with the most populated cities first
-- #
select Name, Population from city WHERE NAME LIKE 'ran%' ORDER BY Population DESC;
Rangoon (Yangon)	3361700
Ranchi	599306
Randburg	341288
Rancagua	212977
Rangpur	191398
Rancho Cucamonga	127743
Randfontein	120838
-- #
-- # 3: Count all cities
-- #
select count(Name) from city;
- 4079
-- #
-- # 4: Get the average population of all cities
-- #
select AVG(Population) from city;
350468.2236
-- #
-- # 5: Get the biggest population found in any of the cities
-- #
select MAX(Population) from city;
10500000
-- alt 
select * from city where Population = (select MAX(Population) from city);
1024	Mumbai (Bombay)	IND	Maharashtra	10500000
-- #
-- # 6: Get the smallest population found in any of the cities
select * from city where Population = (select MIN(Population) from city);
2912	Adamstown	PCN	–	42
-- #
-- #
-- # 7: Sum the population of all cities with a population below 10000
-- #
select SUM(Population) from city where Population <10000;
135210

-- #
-- # 8: Count the cities with the countrycodes MOZ and VNM
-- #
select count(Name) from city where CountryCode IN ('moz', 'vnm');
34
-- #
-- # 9: Get individual count of cities for the countrycodes MOZ and VNM
-- #
select count(Name), CountryCode from city group by CountryCode having CountryCode IN ('moz', 'vnm');
12	MOZ
22	VNM
-- #
-- # 10: Get average population of cities in MOZ and VNM
-- #
select AVG(Population), CountryCode from city group by CountryCode having CountryCode IN ('moz', 'vnm');
261928.7500	MOZ
425673.3182	VNM
-- #
-- # 11: Get the countrycodes with more than 200 cities
select CountryCode, count(Name) from city group by CountryCode having COUNT(Name) > 200;
BRA	250
CHN	363
IND	341
JPN	248
USA	274
-- #
-- # 12: Get the countrycodes with more than 200 cities ordered by city count
-- 
select CountryCode, count(Name) from city group by CountryCode having COUNT(Name) > 200 order by count(name);
JPN	248
BRA	250
USA	274
IND	341
CHN	363
-- #
-- # 13: What language(s) is spoken in the city with a population between 400 and 500 ?

select * from countrylanguage where CountryCode = (select CountryCode from city where Population between 400 and 500)
VAT	Italian	T	0.0
-- #
-- # 14: What are the name(s) of the cities with a population between 500 and 600 people and the language(s) spoken in them
select Language, city.Name, city.Population from countrylanguage 
	join city on countrylanguage.CountryCode = city.CountryCode 
	where city.Population between 500 and 600

English	The Valley	595
English	Bantam	503
Malay	Bantam	503
Chinese	Yaren	559
English	Yaren	559
Kiribati	Yaren	559
Nauru	Yaren	559
Tuvalu	Yaren	559

-- #
-- # 15: What names of the cities are in the same country as the city with a population of 122199 (including the that city itself)
select Name, Population from city where CountryCode = (select CountryCode from city where Population=122199);
Stockholm	750348
Gothenburg [Göteborg]	466990
Malmö	259579
Uppsala	189569
Linköping	133168
Västerås	126328
Örebro	124207
Norrköping	122199
Helsingborg	117737
Jönköping	117095
Umeå	104512
Lund	98948
Borås	96883
Sundsvall	93126
Gävle	90742
-- #
-- # 16: What names of the cities are in the same country as the city with a population of 122199 (excluding the that city itself)
select Name, Population 
from city 
where CountryCode = (select CountryCode from city where Population=122199) 
AND Name <> (select Name from city where Population =122199 );
Stockholm	750348
Gothenburg [Göteborg]	466990
Malmö	259579
Uppsala	189569
Linköping	133168
Västerås	126328
Örebro	124207
Helsingborg	117737
Jönköping	117095
Umeå	104512
Lund	98948
Borås	96883
Sundsvall	93126
Gävle	90742

-- #
-- # 17: What are the city names in the country where Luanda is capital?
select Name from city where CountryCode=(select CountryCode from City where Name='Luanda');
Luanda
Huambo
Lobito
Benguela
Namibe
the stupid way: 
select * from city where CountryCode = (select Code from country where Capital=(select ID from City where Name='Luanda'));
56	Luanda	AGO	Luanda	2022000
57	Huambo	AGO	Huambo	163100
58	Lobito	AGO	Benguela	130000
59	Benguela	AGO	Benguela	128300
60	Namibe	AGO	Namibe	118200
-- #
-- # 18: What are the names of the capital cities in countries in the same region as the city named Yaren
select Name from city where ID IN
(select Capital from country 
	where Region=(
		select Region from country where Code=(
			select CountryCode from city where Name='Yaren'
            )
		)
	);
Palikir
Agaña
Bairiki
Dalap-Uliga-Darrit
Garapan
Yaren
Koror

select city.Name, country.Name, country.Region from city 
join country on city.CountryCode=country.Code
where ID IN
(select Capital from country 
	where Region=(
		select Region from country where Code=(
			select CountryCode from city where Name='Yaren'
            )
		)
	) ;
Palikir	Micronesia, Federated States of	Micronesia
Agaña	Guam	Micronesia
Bairiki	Kiribati	Micronesia
Dalap-Uliga-Darrit	Marshall Islands	Micronesia
Garapan	Northern Mariana Islands	Micronesia
Yaren	Nauru	Micronesia
Koror	Palau	Micronesia

-- #
-- # 19: What unique languages are spoken in the countries in the same region as the city named Riga

select distinct Language from countrylanguage
where countrylanguage.CountryCode in (
	select country.Code from country where Region=(
		select Region from country where country.Code=(
			select CountryCode from city where Name='Riga'
            )
		)
	) 
order by Language;
Belorussian
Estonian
Finnish
Latvian
Lithuanian
Polish
Russian
Ukrainian
-- #
-- # 20: Get the name of the most populous city
-- #
select Name from city where Population=(select MAX(Population) from city)
Mumbai (Bombay)
