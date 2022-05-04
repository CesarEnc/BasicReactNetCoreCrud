import logo from './logo.svg';
import './App.css';
import {store} from './actions/store';
import {Provider} from 'react-redux';
import Persons from './componets/Persons';

function App() {
  return (
    <Provider store={store}>
    <Persons/>
    </Provider>
  );
}

export default App;
