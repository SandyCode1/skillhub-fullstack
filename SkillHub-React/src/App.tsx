import { Routes, Route, Navigate } from "react-router-dom";
import UserListPage from './pages/UserListPage'; // adjust path if needed
import UserFormPage from './pages/UserFormPage'; // adjust path if needed


const App = () => {
  return (
    <Routes>
      <Route path="/" element={<Navigate to="/users" />} />
      <Route path="/users" element={<UserListPage />} />
      <Route path="/users/create" element={<UserFormPage />} />
      <Route path="/users/edit/:id" element={<UserFormPage />} />
      <Route path="*" element={<div>Page Not Found</div>} />
    </Routes>
  );
};
export default App; // ✅ required for default import