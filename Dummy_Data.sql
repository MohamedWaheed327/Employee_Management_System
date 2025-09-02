USE ITI_EMS;


INSERT INTO Departments
    (Name)
VALUES
    ('Human Resources'),
    ('Finance'),
    ('IT');


INSERT INTO JobTitles
    (Title, DepartmentId)
VALUES
    ('Manager', 1),
    ('Accountant', 2),
    ('Developer', 3),
    ('HR Specialist', 1),
    ('IT Support', 3);


INSERT INTO Employees
    (FullName, Email, PhoneNumber, HireDate, Salary, ProfileImagePath, Department_id, Job_id)
VALUES
    ('Ahmed Ali', 'ahmed.ali@example.com', '01011111111', '2021-01-10', 7000.50, NULL, 3, 5),
    ('Mona Hassan', 'mona.hassan@example.com', '01022222222', '2021-02-15', 6500.00, NULL, 1, 6),
    ('Khaled Omar', 'khaled.omar@example.com', '01033333333', '2021-03-20', 8000.00, NULL, 3, 5),
    ('Sara Ibrahim', 'sara.ibrahim@example.com', '01044444444', '2021-04-10', 9000.00, NULL, 1, 3),
    ('Youssef Adel', 'youssef.adel@example.com', '01055555555', '2021-05-05', 7500.00, NULL, 3, 7),
    ('Nourhan Magdy', 'nourhan.magdy@example.com', '01066666666', '2021-06-18', 7200.00, NULL, 3, 5),
    ('Omar Tarek', 'omar.tarek@example.com', '01077777777', '2021-07-12', 8100.00, NULL, 1, 6),
    ('Aya Samir', 'aya.samir@example.com', '01088888888', '2021-08-01', 6700.00, NULL, 2, 4),
    ('Hany Lotfy', 'hany.lotfy@example.com', '01099999999', '2021-09-22', 9500.00, NULL, 3, 5),
    ('Dina Fathy', 'dina.fathy@example.com', '01111111111', '2021-10-15', 8800.00, NULL, 1, 6),
    ('Mahmoud Nabil', 'mahmoud.nabil@example.com', '01122222222', '2021-11-03', 7200.00, NULL, 2, 4),
    ('Heba Mohamed', 'heba.mohamed@example.com', '01133333333', '2021-12-25', 7600.00, NULL, 3, 5),
    ('Mostafa Khalil', 'mostafa.khalil@example.com', '01144444444', '2022-01-05', 7000.00, NULL, 1, 6),
    ('Nadia Farid', 'nadia.farid@example.com', '01155555555', '2022-02-14', 6400.00, NULL, 2, 4),
    ('Hossam Ezzat', 'hossam.ezzat@example.com', '01166666666', '2022-03-20', 8700.00, NULL, 3, 5),
    ('Rania Adel', 'rania.adel@example.com', '01177777777', '2022-04-10', 6900.00, NULL, 1, 3),
    ('Walid Gamal', 'walid.gamal@example.com', '01188888888', '2022-05-16', 7900.00, NULL, 2, 4),
    ('Hager Salah', 'hager.salah@example.com', '01199999999', '2022-06-11', 8200.00, NULL, 3, 7),
    ('Ali Fathi', 'ali.fathi@example.com', '01211111111', '2022-07-21', 7100.00, NULL, 1, 6),
    ('Mariam Said', 'mariam.said@example.com', '01222222222', '2022-08-30', 6600.00, NULL, 2, 4),
    ('Sherif Anwar', 'sherif.anwar@example.com', '01233333333', '2022-09-19', 8700.00, NULL, 3, 5),
    ('Laila Osman', 'laila.osman@example.com', '01244444444', '2022-10-09', 9200.00, NULL, 1, 6),
    ('Adel Fawzy', 'adel.fawzy@example.com', '01255555555', '2022-11-01', 7700.00, NULL, 2, 4),
    ('Nour ElDin', 'nour.eldin@example.com', '01266666666', '2022-12-12', 8500.00, NULL, 3, 5),
    ('Hala Reda', 'hala.reda@example.com', '01277777777', '2023-01-23', 7400.00, NULL, 1, 3),
    ('Ibrahim Salem', 'ibrahim.salem@example.com', '01288888888', '2023-02-17', 8100.00, NULL, 2, 4),
    ('Farah Mamdouh', 'farah.mamdouh@example.com', '01299999999', '2023-03-27', 6800.00, NULL, 3, 5),
    ('Karem Lotfy', 'karem.lotfy@example.com', '01311111111', '2023-04-30', 7600.00, NULL, 1, 6),
    ('Yasmin Fadl', 'yasmin.fadl@example.com', '01322222222', '2023-05-19', 8000.00, NULL, 2, 4),
    ('Samy Tawfik', 'samy.tawfik@example.com', '01333333333', '2023-06-08', 9400.00, NULL, 3, 7);

SELECT * from JobTitles;