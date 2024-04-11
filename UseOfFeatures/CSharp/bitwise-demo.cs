// Define permission constants
const int PERMISSION_ONE = 1 << 0;
const int PERMISSION_TWO = 1 << 1;
const int PERMISSION_THREE = 1 << 2;

// Create a user object with permissions
var user = new {
    Name = "John Doe",
    Permissions = PERMISSION_ONE | PERMISSION_TWO
};

// Function to check if a user has a specific permission
public bool HasPermission(User user, int permission) {
    return (user.Permissions & permission) == permission;
}

// Check if user has permission 1
if (HasPermission(user, PERMISSION_ONE)) {
    Console.WriteLine("User has permission 1");
}

// Check if user has permission 2
if (HasPermission(user, PERMISSION_TWO)) {
    Console.WriteLine("User has permission 2");
}

// Check if user has permission 3
if (HasPermission(user, PERMISSION_THREE)) {
    Console.WriteLine("User has permission 3");
}

// Authorized locations
const int LOCATION_ONE = 3;
const int LOCATION_TWO = 5;
const int LOCATION_THREE = 7;

// Function to check if a user is authorized to access a location
public bool IsAuthorized(User user, int location) {
    return (user.Permissions & location) == location;
}

// Check if user is authorized to access location 1
if (IsAuthorized(user, LOCATION_ONE)) {
    Console.WriteLine("User is authorized to access location 1");
}

// Check if user is authorized to access location 2
if (IsAuthorized(user, LOCATION_TWO)) {
    Console.WriteLine("User is authorized to access location 2");
}

// Check if user is authorized to access location 3
if (IsAuthorized(user, LOCATION_THREE)) {
    Console.WriteLine("User is authorized to access location 3");
}


if (HasPermission(user, PERMISSION_ONE | PERMISSION_TWO)) {
    Console.WriteLine("User has permission 1 and permission 2");

}if (IsAuthorized(user, LOCATION_ONE | LOCATION_TWO)) {
    Console.WriteLine("User is authorized to access location 1 and location 2");
}