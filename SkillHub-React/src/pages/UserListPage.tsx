import React, { useEffect, useState } from "react";
import { getUsers, deleteUser } from "../services/userService";
import { Link, useNavigate } from "react-router-dom";

const UserListPage = () => {
  const [users, setUsers] = useState<any[]>([]);
  const navigate = useNavigate();

  useEffect(() => {
    loadUsers();
  }, []);

  const loadUsers = async () => {
    const data = await getUsers();
    setUsers(data);
  };

  const handleDelete = async (id: string) => {
    if (window.confirm("Are you sure?")) {
      await deleteUser(id);
      await loadUsers();
    }
  };

  return (
    <div>
      <h1>User List</h1>
      <button onClick={() => navigate("/users/create")}>Add User</button>
      <table border={1} cellPadding={10} style={{ marginTop: 10 }}>
        <thead>
          <tr>
            <th>Name</th>
            <th>Email</th>
            <th>Phone</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {users.map((u) => (
            <tr key={u.id}>
              <td>{u.name}</td>
              <td>{u.email}</td>
              <td>{u.phone}</td>
              <td>
                <Link to={`/users/edit/${u.id}`}>
                  <button>Edit</button>
                </Link>
                <button onClick={() => handleDelete(u.id)}>Delete</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default UserListPage;
