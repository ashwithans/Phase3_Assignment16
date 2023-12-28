CREATE DATABASE School2023Db
USE School2023Db

CREATE TABLE Category (
    ID INT PRIMARY KEY,
    CourseCategory NVARCHAR(50) NOT NULL UNIQUE
)


CREATE TABLE Course (
    ID INT PRIMARY KEY,
    Name NVARCHAR(50),
    Fee FLOAT,
    StartDate DATETIME,
    CourseCategoryID INT,
    FOREIGN KEY (CourseCategoryID) REFERENCES Category(ID)
)

SELECT * FROM Category
SELECT * FROM Course

