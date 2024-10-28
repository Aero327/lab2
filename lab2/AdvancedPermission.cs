namespace lab2;

public class AdvancedPermission : PermissionPair
{
    // Дополнительные поля
    private bool CanDelete { get; set; }
    private bool CanViewSensitiveData { get; set; }

    // Конструктор по умолчанию
    public AdvancedPermission() : base()
    {
        CanDelete = false;
        CanViewSensitiveData = false;
    }

    // Конструктор с параметрами для всех четырех полей
    public AdvancedPermission(bool isAdmin, bool canEdit, bool canDelete, bool canViewSensitiveData) : base(isAdmin, canEdit)
    {
        CanDelete = canDelete;
        CanViewSensitiveData = canViewSensitiveData;
    }

    // Конструктор копирования
    public AdvancedPermission(AdvancedPermission other) : base(other)
    {
        CanDelete = other.CanDelete;
        CanViewSensitiveData = other.CanViewSensitiveData;
    }

    // Метод для проверки наличия полного доступа
    public bool HasFullAccess()
    {
        return IsAdmin && CanEdit && CanDelete && CanViewSensitiveData;
    }

    // Метод для проверки наличия ограниченного доступа (только на просмотр и редактирование)
    public bool HasLimitedAccess()
    {
        return !IsAdmin && CanEdit && !CanDelete && !CanViewSensitiveData;
    }

    // Метод для проверки возможности полного управления
    public bool CanManageAll()
    {
        return IsAdmin && CanEdit && CanDelete;
    }

    // Переопределение метода ToString для включения всех прав
    public override string ToString()
    {
        return base.ToString() + $", CanDelete: {CanDelete}, CanViewSensitiveData: {CanViewSensitiveData}, " +
               $"HasFullAccess: {HasFullAccess()}, HasLimitedAccess: {HasLimitedAccess()}, CanManageAll: {CanManageAll()}";
    }
}