import React, { Suspense } from "react";
import { BrowserRouter as Router, Routes,Route } from "react-router-dom";
import Submitted from "./assets/Components/SubmittedPage";
import { Home } from "./assets/Components/Home";
import './App.css'

function App() {
  

  return (
    <>
      <Router>

        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/submitted" element={<Submitted />} />
        </Routes>
      </Router>
      
    </>
  )
}

export default App
