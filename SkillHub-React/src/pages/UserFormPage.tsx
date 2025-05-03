import React, { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { getUserById, createUser, updateUser } from "../services/userService";

const UserFormPage = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const isEdit = !!id;

  const [user, setUser] = useState({ name: "", email: "", phone: "" });

  useEffect(() => {
    if (isEdit) {
      (async () => {
        const data = await getUserById(id!);
        setUser(data);
      })();
    }
  }, [id]);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setUser({ ...user, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    isEdit ? await updateUser({ id, ...user }) : await createUser(user);
    navigate("/users");
  };

  return (
    <div>
      <h2>{isEdit ? "Edit" : "Create"} User</h2>
      <form onSubmit={handleSubmit}>
        <label>Name: </label>
        <input name="name" value={user.name} onChange={handleChange} required />
        <br />
        <label>Email: </label>
        <input name="email" value={user.email} onChange={handleChange} required />
        <br />
        <label>Phone: </label>
        <input name="phone" value={user.phone} onChange={handleChange} required />
        <br />
        <button type="submit">{isEdit ? "Update" : "Create"}</button>
      </form>
    </div>
  );
};

export default UserFormPage;
