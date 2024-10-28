namespace lab2;
public class PermissionPair
{
    // Поля
    protected bool IsAdmin { get; set; }
    protected bool CanEdit { get; set; }

    // Конструктор по умолчанию
    public PermissionPair()
    {
        IsAdmin = false;
        CanEdit = false;
    }

    // Конструктор с параметрами
    public PermissionPair(bool isAdmin, bool canEdit)
    {
        IsAdmin = isAdmin;
        CanEdit = canEdit;
    }

    // Конструктор копирования
    public PermissionPair(PermissionPair other)
    {
        IsAdmin = other.IsAdmin;
        CanEdit = other.CanEdit;
    }

    // Метод для проверки импликации (если IsAdmin => CanEdit)
    public bool Implication()
    {
        return !IsAdmin || CanEdit; // Если пользователь — администратор, то он также должен иметь право на редактирование
    }

    // Переопределение метода ToString для представления полей
    public override string ToString()
    {
        return $"IsAdmin: {IsAdmin}, CanEdit: {CanEdit}, Implication(IsAdmin => CanEdit): {Implication()}";
    }
}
