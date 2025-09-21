
---

## 🔹 `src/App/Program.cs`
```csharp
﻿using App;

using var db = new AppDbContext();
var actions = new AppActions(db);


actions.AddOne();
actions.AddMany();
actions.Save();

actions.UpdateOne();
actions.UpdateMany();
actions.Save();

Console.WriteLine($"Кількість записів: {actions.CountRecords()}");

var one = actions.GetOneByCondition();
Console.WriteLine(one != null ? $"Знайшов: {one.Name}, {one.Age}" : "Не знайдено");

var many = actions.GetManyByCondition();
Console.WriteLine("Записи з віком >= 30:");
many.ForEach(p => Console.WriteLine($"{p.Name}, {p.Age}"));

actions.DeleteOne();
actions.DeleteMany();
actions.Save();

Console.WriteLine($"Кількість після видалення: {actions.CountRecords()}");
