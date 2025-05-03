import axios from "axios";

const API_URL = "http://localhost:5048/api/users"; // Adjust to match FastEndpoints route

export const getUsers = async () => {
  const res = await axios.get(API_URL);
  console.log(API_URL);
  console.log(res.data);
  return res.data;
};

export const getUserById = async (id: string) => {
  const res = await axios.get(`${API_URL}/${id}`);
  return res.data;
};

export const createUser = async (user: any) => {
  await axios.post(API_URL, user);
};

export const updateUser = async (user: any) => {
  await axios.put(API_URL, user);
};

export const deleteUser = async (id: string) => {
  await axios.delete(`${API_URL}/${id}`);
};
