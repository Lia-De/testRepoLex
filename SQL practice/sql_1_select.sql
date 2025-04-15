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
    -- #
    -- #
    -- # 3: Get everything on the cities whose district is "aceh"
    -- # (Hint: 2 rows)
use world;
select * from city WHERE District ='aceh';
- 2 rows
    -- #
    -- #
    -- # 4: Get only the name of the cities where the countrycode is "bfa"
    -- #
use world;
select * from city where CountryCode='bfa';
- 3 rows
    -- #
    -- # 5: Get both the name and district of the cities where the countrycode is "tto"

select Name, District from city WHERE CountryCode='tto';
- 2 rows
    -- #
    -- #
    -- # 6: Get the name and district named as nm,dist from the cities where the countrycode is "arm"
    -- #
select Name as nm, District as dist from city WHERE CountryCode='arm';
- 3 rows
    -- #
    -- # 7: Get the cities with a name that starts with "bor"
    -- #
select Name from city where Name like 'bor%';
- 4 rows
    -- #
    -- # 8: Get the cities with a name that contains the string "orto"
    -- #
select Name from city where Name like '%orto%';
- 7 rows
    -- #
    -- # 9: Get the cities that has a population below 1000
    -- #
select * from city where Population < 1000;
- 11 rows
    #
    -- # 10: Get the unique countrycodes from the cities that has a population below 1000
select distinct CountryCode from city where Population < 1000;
- 9 rows

    -- #
    -- # 11: Get the cities with the countrycode UKR that has more than 1000000 (one million) in population
    -- #
select * from city where Population > 1000000 AND CountryCode='ukr';
- 5 rows
    -- #
    -- # 12: Get the cities with a population of below 200 or above 9500000 (9.5 million)
    -- #
select * from city where Population < 200 OR Population > 9500000 ;
- 7 rows
    -- #
    -- # 13: Get the cities with the countrycodes TJK, MRT, AND, PNG, SJM
select * from city where CountryCode IN ('TJK', 'MRT', 'AND', 'PNG', 'SJM');
- 7 rows
    -- #
    -- #
    -- # 14: Get the cities with a population between 200 and 700 inclusive
    -- #
    select * from city where Population <= 700 AND Population >= 200;
    alt 
    select * from city where Population BETWEEN 200 AND 700;
    - 7 rows
    -- #
    -- # 15: Get the countries with a population between 8000 and 20000 inclusive
    -- #
    select * from country where Population BETWEEN 2000 AND 8000;
    - 9 rows
    -- #
    -- # 16: Get the name of the countries with a independence year (indepyear) before year 0
select * from country where IndepYear <0;
- 3 rows
    -- #
    -- #
    -- # 17: Get the countries that has no recorded independence year and a population above 1000000
    -- #
    select * from country where IndepYear IS NULL AND Population > 1000000;
    -3 rows
    -- #
    -- # 18: Get countries with a SurfaceArea below 10 and a defined LifeExpectancy
    -- 
    select * from country where LifeExpectancy IS NOT NULL AND SurfaceArea < 10;
    - 2 rows
