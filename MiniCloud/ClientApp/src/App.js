import React, { useEffect, useState } from 'react';
import Navbar from "./components/navbar/Navbar";
import './app.css'
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Registration from "./components/registration/Registration";
import Login from './components/registration/Login';
import { useDispatch, useSelector } from "react-redux";
import { auth } from "./actions/user"
import { setAuth } from "./reducers/userReducer";


function App() {

    const isAuth = useSelector(state => state.user.isAuth)
    const dispatch = useDispatch()

    useEffect(() => {
        if (localStorage.getItem('token')) {
           // dispatch(auth())
            setAuth(true);
        }
    }, [])


    return (
            <BrowserRouter>
                <div className='app'>
                    <Navbar />
                    <div className="wrap">
                        {!isAuth &&
                            <Routes>
                                <Route path="/registration" element={<Registration />} />
                                <Route path="/login" element={<Login />} />
                            </Routes>
                        }
                    </div>
                </div>
            </BrowserRouter>
    );
}


export default App;