    -- # SQL select query exercise
    -- #
    -- # World database layout:
    -- # To use this database from a default MySQL install, type: use world;
    -- #
    -- # Table: City
    -- # Columns: Id,Name,CountryCode,District,Population
    -- #
    -- # Table: Country
    -- # Columns: Code, Name, Continent, Region, SurfaceArea, IndepYear, Population, LifeExpectancy, GNP, Capital
    -- #
    -- # Table: CountryLanguage
    -- # Columns: CountryCode, Language, IsOfficial,Percentage
    -- #
    -- #
    -- # 1: Get a query to return "Hello World", 123
    -- # (Hint: 1 row, 2 columns)
    -- #
    -- #
    -- # 2: Get everything from the city table
    -- # (Hint: Many many rows)
use world;
select * from city;
 - 1000+ rows
    -- #
    -- #
    -- # 3: Get everything on the cities whose district is "aceh"
    -- # (Hint: 2 rows)
use world;
select * from city WHERE District ='aceh';
982	Banda Aceh	IDN	Aceh	143409
999	Lhokseumawe	IDN	Aceh	109600
    -- #
    -- #
    -- # 4: Get only the name of the cities where the countrycode is "bfa"
    -- #
use world;
select * from city where CountryCode='bfa';
- 3 rows
549	Ouagadougou	BFA	Kadiogo	824000
550	Bobo-Dioulasso	BFA	Houet	300000
551	Koudougou	BFA	Boulkiemdé	105000
    -- #
    -- # 5: Get both the name and district of the cities where the countrycode is "tto"

select Name, District from city WHERE CountryCode='tto';
Chaguanas	Caroni
Port-of-Spain	Port-of-Spain
    -- #
    -- #
    -- # 6: Get the name and district named as nm,dist from the cities where the countrycode is "arm"
    -- #
select Name as nm, District as dist from city WHERE CountryCode='arm';
Yerevan	Yerevan
Gjumri	Širak
Vanadzor	Lori
    -- #
    -- # 7: Get the cities with a name that starts with "bor"
    -- #
select Name from city where Name like 'bor%';
Borujerd
Bordeaux
Borås
Borisov
    -- #
    -- # 8: Get the cities with a name that contains the string "orto"
    -- #
select Name from city where Name like '%orto%';
Porto-Novo
Porto Alegre
Porto Velho
Hortolândia
Portoviejo
Naçala-Porto
Porto
    -- #
    -- # 9: Get the cities that has a population below 1000
    -- #
select * from city where Population < 1000;
61	South Hill	AIA	–	961
62	The Valley	AIA	–	595
1791	Flying Fish Cove	CXR	–	700
2316	Bantam	CCK	Home Island	503
2317	West Island	CCK	West Island	167
2728	Yaren	NRU	–	559
2805	Alofi	NIU	–	682
2806	Kingston	NFK	–	800
2912	Adamstown	PCN	–	42
3333	Fakaofo	TKL	Fakaofo	300
3538	Città del Vaticano	VAT	–	455
    #
    -- # 10: Get the unique countrycodes from the cities that has a population below 1000
select distinct CountryCode from city where Population < 1000;
AIA
CXR
CCK
NRU
NIU
NFK
PCN
TKL
VAT

    -- #
    -- # 11: Get the cities with the countrycode UKR that has more than 1000000 (one million) in population
    -- #
select * from city where Population > 1000000 AND CountryCode='ukr';
3426	Kyiv	UKR	Kiova	2624000
3427	Harkova [Harkiv]	UKR	Harkova	1500000
3428	Dnipropetrovsk	UKR	Dnipropetrovsk	1103000
3429	Donetsk	UKR	Donetsk	1050000
3430	Odesa	UKR	Odesa	1011000
    -- #
    -- # 12: Get the cities with a population of below 200 or above 9500000 (9.5 million)
    -- #
select * from city where Population < 200 OR Population > 9500000 ;
206	São Paulo	BRA	São Paulo	9968485
939	Jakarta	IDN	Jakarta Raya	9604900
1024	Mumbai (Bombay)	IND	Maharashtra	10500000
1890	Shanghai	CHN	Shanghai	9696300
2317	West Island	CCK	West Island	167
2331	Seoul	KOR	Seoul	9981619
2912	Adamstown	PCN	–	42
    -- #
    -- # 13: Get the cities with the countrycodes TJK, MRT, AND, PNG, SJM
select * from city where CountryCode IN ('TJK', 'MRT', 'AND', 'PNG', 'SJM');
55	Andorra la Vella	AND	Andorra la Vella	21189
2509	Nouakchott	MRT	Nouakchott	667300
2510	Nouâdhibou	MRT	Dakhlet Nouâdhibou	97600
2884	Port Moresby	PNG	National Capital Dis	247000
938	Longyearbyen	SJM	Länsimaa	1438
3261	Dushanbe	TJK	Karotegin	524000
3262	Khujand	TJK	Khujand	161500
    -- #
    -- #
    -- # 14: Get the cities with a population between 200 and 700 inclusive
    -- #
    select * from city where Population <= 700 AND Population >= 200;
    alt 
    select * from city where Population BETWEEN 200 AND 700;
62	The Valley	AIA	–	595
1791	Flying Fish Cove	CXR	–	700
2316	Bantam	CCK	Home Island	503
2728	Yaren	NRU	–	559
2805	Alofi	NIU	–	682
3333	Fakaofo	TKL	Fakaofo	300
3538	Città del Vaticano	VAT	–	455
    -- #
    -- # 15: Get the countries with a population between 8000 and 20000 inclusive
    -- #
    select * from country where Population BETWEEN 2000 AND 8000;
AIA	Anguilla	North America	Caribbean	96.00		8000
CXR	Christmas Island	Oceania	Australia and New Zealand	135.00		2500
FLK	Falkland Islands	South America	South America	12173.00		2000
NFK	Norfolk Island	Oceania	Australia and New Zealand	36.00		2000
NIU	Niue	Oceania	Polynesia	260.00		2000
SHN	Saint Helena	Africa	Western Africa	314.00		6000
SJM	Svalbard and Jan Mayen	Europe	Nordic Countries	62422.00		3200
SPM	Saint Pierre and Miquelon	North America	North America	242.00		7000
TKL	Tokelau	Oceania	Polynesia	12.00		2000
    -- #
    -- # 16: Get the name of the countries with a independence year (indepyear) before year 0
select * from country where IndepYear <0;
CHN	China	Asia	Eastern Asia	9572900.00	-1523
ETH	Ethiopia	Africa	Eastern Africa	1104300.00	-1000
JPN	Japan	Asia	Eastern Asia	377829.00	-660
    -- #
    -- #
    -- # 17: Get the countries that has no recorded independence year and a population above 1000000
    -- #
    select * from country where IndepYear IS NULL AND Population > 1000000;
HKG	Hong Kong	Asia	Eastern Asia	1075.00		6782000
PRI	Puerto Rico	North America	Caribbean	8875.00		3869000
PSE	Palestine	Asia	Middle East	6257.00		3101000
    -- #
    -- # 18: Get countries with a SurfaceArea below 10 and a defined LifeExpectancy
    -- 
    select * from country where LifeExpectancy IS NOT NULL AND SurfaceArea < 10;
GIB	Gibraltar	Europe	Southern Europe	6.00		25000	79.0
MCO	Monaco	Europe	Western Europe	1.50	1861	34000	78.8
