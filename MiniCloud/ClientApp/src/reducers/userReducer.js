const SET_USER = "SET_USER"
const LOGOUT = "LOGOUT"
const SET_AUTH = "SET_AUTH"


const defaultState = {
    currentUser: {},
    isAuth: false
}

export default function userReducer(state = defaultState, action) {
    switch (action.type) {
        case SET_USER:
            return {
                ...state,
                currentUser: action.payload,
                isAuth:true
            }
        case SET_AUTH:
            return {
                ...state,
                isAuth: action.payload
            }
        case LOGOUT:
            localStorage.removeItem('token')
            return {
                ...state,
                currentUser: {},
                isAuth: false
            }
        default:
            return state
    }
}


export const setUser = user => ({ type: SET_USER, payload: user })
export const logout = () => ({ type: LOGOUT })
export const setAuth = isAuth => ({ type: SET_AUTH, payload :isAuth})