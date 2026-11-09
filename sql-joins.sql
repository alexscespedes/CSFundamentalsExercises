-- Exercise 1 — SQL: Joins (Online store)

SELECT c.Id, c.FullName, COUNT(o.CustomerId) AS OrderCount
FROM Customers c
LEFT JOIN Orders o ON o.CustomerId = c.Id
GROUP BY c.Id, c.FullName
ORDER BY c.FullName;

-- Exercise 2 — SQL: Joins again (same store)

SELECT c.FullName, c.City
FROM Customers c
LEFT JOIN Orders o ON o.CustomerId = c.Id
WHERE o.Id IS NULL
ORDER BY c.FullName;

-- Exercise 3 — SQL: Aggregation with a filter (same store)
SELECT c.FullName, SUM(o.Total) AS TotalSpent
FROM Customers c
INNER JOIN Orders o ON o.CustomerId = c.Id
GROUP BY c.Id, c.FullName
HAVING SUM(o.Total) > 100
ORDER BY TotalSpent DESC;

-- Exercise 4 — SQL: WHERE and HAVING together (same store)
SELECT c.FullName, COUNT(o.Id) AS OrderCount, SUM(o.Total) AS TotalSpent
FROM Customers c
INNER JOIN Orders o ON o.CustomerId = c.Id
WHERE o.OrderDate >= '2026-09-01' AND o.OrderDate < '2026-10-01'
GROUP BY c.Id, c.FullName
HAVING COUNT(o.Id) >= 2
ORDER BY OrderCount DESC;