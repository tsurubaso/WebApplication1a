import React from "react";
import "../App.css";
import "bootstrap/dist/css/bootstrap.css";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Login from "./Login";
import Registration from "./Registration";

const RouterPage = () => {
  return (
    <Router>
      <Routes>
        <Route path="/"  element={ <Login/> } />
        <Route path="/registration" element={ <Registration/> } />
      </Routes>
    </Router>
  );
};

export default RouterPage;
