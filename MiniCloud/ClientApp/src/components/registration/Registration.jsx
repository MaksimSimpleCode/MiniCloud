import React, { useState } from 'react';
import './authorization.css'
import Input from "../../utils/input/Input";
import { registration } from "../../actions/user";

const Registration = () => {
    const [email, setEmail] = useState("")
    const [password, setPassword] = useState("")
    const [name, setName] = useState("")

    return (
        <div className='authorization'>
            <div className="authorization__header">Регистрация</div>
            <Input value={email} setValue={setEmail} type="text" placeholder="Введите email..." />
          {/*  <Input value={name} setValue={setName} type="text" placeholder="Введите логин..." />*/}
            <Input value={password} setValue={setPassword} type="password" placeholder="Введите пароль..." />
            <button className="authorization__btn" onClick={() => registration(email,/*name,*/ password)}>Войти</button>
        </div>
    );
};

export default Registration;